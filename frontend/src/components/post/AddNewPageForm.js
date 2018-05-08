import React, {Component} from 'react';
import {
  Button,
  TextArea,
  Dropdown,
  Form,
  FormField,
  Container,
  Grid,
  Checkbox,
  Divider, 
  Input,
  Label,
  Image
} from 'semantic-ui-react';
import Validator from 'validator';
import PropTypes from 'prop-types';

const options = [
  {
    value: 'sport',
    text: 'Sport'
  }, {
    value: 'gotowanie',
    text: 'Gotowanie'
  }, {
    value: 'spanie',
    text: 'Spanie'
  }, {
    value: 'zbieranieGrzybow',
    text: 'Zbieranie Grzybow'
  }
]




class AddNewPageForm extends Component {
  componentWillMount() {
    this.setState({
      data: {
        content: '',
        postPhoto: [],
        imageUrl: '',
        toGroup: [],
        place: ''
      },
      withPhoto: false,
      withPlace: false
      
      
    })
    this.onCheckBoxChangePhoto=this.onCheckBoxChangePhoto.bind(this);
    this.onCheckBoxChangePlace=this.onCheckBoxChangePlace.bind(this);
  }




  onChange = e => {
    this.setState({
    data: {
      ...this.state.data,
      [e.target.name]: e.target.value
    },
  });
}

  onCheckBoxChangePhoto(e) {
    this.setState({
      withPhoto: !this.state.withPhoto,
      data:{
        postPhoto: [],
        imageUrl: ''
      }   
    });
    
  }
  onCheckBoxChangePlace(e) {
    this.setState({withPlace: !this.state.withPlace});
  }

  onChangeGroups = (e, {value}) => this.setState({
    data: {
      ...this.state.data,
      toGroup: value
    }
  });

  onSubmit = (event) => {
    event.preventDefault();
    const errors = this.validate(this.state.data);
    this.setState({errors});
    if (!this.state.isError) {
      this
        .props
        .submit(this.state.data)
      // TODO when Api ready .catch(err => this.setState({errors:
      // err.response.data.errors, loading: false}))
    }
  }
  validate = (data) => {
    const errors = {};
    this.setState({isError: false});
    //Validate content;
    errors.content = "";
    if (!Validator.isLength(data.content, 1, 1000)) 
      errors.content += "Post musi mieć od 1 do 100 znaków";
    
    //Validate forGroups
    errors.forGroups = "";
    return errors;
  }

  fileSelectedHandler = (e,value) => {
    const file    = e.target.files[0];
    const reader  = new FileReader();
  
    reader.onloadend = () => {
        this.setState({
            imageUrl: reader.result
        })
    }
    if (file) {
        reader.readAsDataURL(file);
        this.setState({
            imageUrl :reader.result,
            postPhoto: file
        })
    } 
    else {
        this.setState({
            imageUrl: ""
        })
    }
  }

  render() {
    const {data, withPhoto, withPlace} = this.state;
    return (
      <Container>
        <Grid>
          <Grid.Row centered>
            <Grid.Column width={9}>
              <h1>Dodaj post</h1>
              <Form onSubmit={this.onSubmit}>
                <Form.Field
                  id='form-textarea-control-opinion'
                  name="content"
                  placeholder="Wpisz treść posta..."
                  value={data.content}
                  onChange={this.onChange}
                  control={TextArea}
                  label='Treść posta:'
                  />

                <Form.Field>
                  <Checkbox
                  name="withPhoto" 
                  label='Chcę dołączyć zdjęcie'
                  value={withPhoto}
                  onChange={this.onCheckBoxChangePhoto}                  
                  />
                </Form.Field>
                {withPhoto && <div>
                  <Form.Field>
                    <label>Wybierz zdjęcie
                    </label>
                    <Input 
                    type='file'
                    accept="image/*"
                    name='postPhoto' 
                    onChange={this.fileSelectedHandler}
                    />
                  </Form.Field>
                    <Label> Podgląd obrazka</Label>
                    <Image src={this.state.imageUrl} size='small' />                  
                </div>}


                <Form.Field>
                  <Checkbox
                  name="withPlace" 
                  label='Chcę dołączyć miejsce'
                  value={withPlace}
                  onChange={this.onCheckBoxChangePlace}                  
                  />
                </Form.Field>
                {withPlace && <div>
                  <Form.Field>
                        <Label>Miejsce</Label>
                        <Input 
                        placeholder='Dodaj miejsce...'
                        name='place'
                        value={data.place}
                        onChange={this.onChange}
                        />
                    </Form.Field>
                  
                </div>}

                
                <FormField>
                  <Dropdown
                    placeholder='Dodaj do...'
                    name="forGroup"
                    fluid
                    multiple
                    search
                    selection
                    options={options}
                    value={data.toGroup}
                    onChange={this.onChangeGroups}/>
                </FormField>
                <Button primary content="Dodaj post" type="submit"/>
              </Form>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </Container>
    );
  }
}

AddNewPageForm.propTypes = {
  submit: PropTypes.func
}

export default AddNewPageForm;
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
  Image,
  Segment,
  Icon,
  Header,
  Modal,
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

const styles = {
  root: {
    display: 'flex',
    justifyContent: 'space-around',
    alignItems: 'center',
    height: '98vh',
    flexDirection: 'column',
    "line-height": "1.6"
  },
  segment: {
    background: "rgba(0, 0, 0, 0.6)"
  },
  input:{
      'border-bottom':"3px solid #333333",
      background:"transparent"
  },
  button: {
    "text-align": "center"
  },
  modal: {
    display: 'flex',
    justifyContent: 'space-around',
    alignItems: 'center',
    flexDirection: 'column',
    "line-height": "1.6"
  }
}

const font = {
  root: {
    "fontSize": "20px",
    color: "white"
  },
  linkFont: {
    "fontSize": "20px",
    color:"rgb(190,190,190)"
  },
  h1: {
    "text-align": "center"
  },
  checkbox: {
    "fontSize": "15px",
    color: "white"
  }
}




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
      <div style = {styles.root}>
        <Segment inverted style = {styles.segment}>
          <Container style={{'width': 900}}> 
            {/* <Grid>   */}
              {/* <Grid.Row centered> */}
                {/* <Grid.Column width={9}> */}
                <Header as='h1' textAlign='center' inverted >
                <Icon name='newspaper' />
                  Dodaj post
                </Header>
                  <Form onSubmit={this.onSubmit} >
                    <Form.Field>
                    <label style = {font.root}>Treść postu: </label>
                    </Form.Field>
                    <Form.Field style = {styles.input}
                      id='form-textarea-control-opinion'
                      name="content"
                      placeholder="Wpisz treść posta..."
                      value={data.content}
                      onChange={this.onChange}
                      control={TextArea}
                      //label='Treść posta:'
                      />

                    {/* <Divider /> */}
                    <Form.Field>
                      <Container>
                      <label style = {font.checkbox}>Chcę dołączyć zdjęcie </label>
                      <Checkbox style = {font.root} 
                      name="withPhoto" 
                      //label='Chcę dołączyć zdjęcie' 
                      value={withPhoto}
                      onChange={this.onCheckBoxChangePhoto}                  
                      />
                    </Container>
                    </Form.Field>
                    {withPhoto && <div>
                      <Form.Field>
                        <label style = {font.root}>Wybierz zdjęcie:</label>
                        <Input transparent
                        type='file'
                        accept="image/*"
                        name='postPhoto' 
                        onChange={this.fileSelectedHandler}
                        />
                      
                        <label style = {font.root}> Podgląd obrazka</label>
                        <Image src={this.state.imageUrl} size='small' bordered/>
                        {/* <Divider />   */}
                        </Form.Field>                
                    </div>} 
                    
                    
                    {/* <Modal trigger={<Button>Show Modal</Button>} >
                    <Container style={styles.root}>
                      <Modal.Header>Select a Photo</Modal.Header>
                      <Modal.Content image >
                        <Image wrapped size='medium' src='/assets/images/avatar/large/rachel.png' />
                        <Modal.Description>
                          <Header>Default Profile Image</Header>
                          <p>We've found the following gravatar image associated with your e-mail address.</p>
                          <p>Is it okay to use this photo?</p>
                        </Modal.Description>
                      </Modal.Content>
                    </Container>
                    </Modal>  */}
                    

                    <Form.Field >
                      <Container>
                      <label style = {font.checkbox}>Chcę dodać miejsce </label>
                      <Checkbox style = {font.root}
                      name="withPlace" 
                      //label='Chcę dołączyć miejsce'
                      value={withPlace}
                      onChange={this.onCheckBoxChangePlace}                  
                      />
                      </Container>
                    </Form.Field>
                    {withPlace && <div>
                      <Form.Field>
                            <label style = {font.root}>Miejsce:</label>
                            {/* <Divider hidden /> */}
                            <Input transparent
                            placeholder='Dodaj miejsce...'
                            name='place'
                            value={data.place}
                            onChange={this.onChange}
                            />
                        </Form.Field>
                      
                    </div>}
                    {/* <Divider /> */}
                    
                    <FormField>
                      <label style = {font.root}>Wybierz grupę: </label>
                      <Dropdown style = {styles.input}
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
                    <Container textAlign="center">
                    <Button animated="vertical" 
                        size="huge"  
                        type="submit">
                        <Button.Content visible>Dodaj</Button.Content>
                        <Button.Content hidden>
                          <Icon name="add" />
                        </Button.Content>
                      </Button>
                    </Container> 
                  </Form>
                {/* </Grid.Column> */}
              {/* </Grid.Row> */}
            {/* </Grid> */}
            
          </Container>
        </Segment>
      </div>
    );
  }
}

AddNewPageForm.propTypes = {
  submit: PropTypes.func
}

export default AddNewPageForm;
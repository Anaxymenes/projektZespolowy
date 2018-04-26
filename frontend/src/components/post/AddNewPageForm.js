import React, {Component} from 'react';
import {
  Button,
  TextArea,
  Dropdown,
  Form,
  FormField,
  Container,
  Grid
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
        toGroup: []
      }
    })
  }

  onChange = e => this.setState({
    data: {
      ...this.state.data,
      [e.target.name]: e.target.value
    }
  });

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
  render() {
    const {data} = this.state;
    return (
      <Container>
        <Grid>
          <Grid.Row centered>
            <Grid.Column width={9}>
              <h1 className="text-xs-center">Dodaj post</h1>
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
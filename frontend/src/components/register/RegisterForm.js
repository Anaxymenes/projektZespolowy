import React from 'react';
import {Link} from 'react-router-dom';
import Validator from 'validator';
import InlineError from '../common/InlineError';
import PropTypes from 'prop-types';
import { Container, Header, Icon, Form, Button, Segment, Input } from 'semantic-ui-react';

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
      'border-bottom':"3px solid #333333"
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
  }
}

class RegisterForm extends React.Component {
  state = {
    data: {
      firstName: "",
      lastName: "",
      password: "",
      repeatedPassword: "",
      email: "",
      birthdate: ""
    },
    errors: {},
    isError: false,
    loading: false
  };

  onChange = e => this.setState({
    data: {
      ...this.state.data,
      [e.target.name]: e.target.value
    }
  });
 //TODO Trzeba kliknąć 2 razy żeby zalogowało? Dlaczego?
  onSubmit = (event) => {
    event.preventDefault();
    const errors = this.validate(this.state.data);
    this.setState({errors});
    if (!this.state.data.isError) {
      this.setState({loading: true});
      this
        .props
        .submit(this.state.data)
        .catch(err => this.setState({errors: err.response.data.errors, loading: false}));
    }
  }

  validate = (data) => {
    const errors = {};
    //this.setState({isError: false});
    //FirstNameValidation
    errors.firstName = "";
    if (!Validator.isAlpha(data.firstName, 'pl-PL') && (!Validator.isEmpty(data.firstName))) {
      errors.firstName += "Pole może zawierać tylko litery. ";
      this.setState({isError: true});
    }
    if (!Validator.isLength(data.firstName, 2, 32)) {
      errors.firstName += "Pole powinno zawierać od 2 do 32 znaków. ";
      this.setState({isError: true});
    }
    //SecondNameValidation
    errors.lastName = "";
    if (!Validator.isAlpha(data.lastName, 'pl-PL') && (!Validator.isEmpty(data.lastName))) {
      errors.lastName += "Pole może zawierać tylko litery ";
      this.setState({isError: true});
    }
    if (!Validator.isLength(data.lastName, 2, 32)) {
      errors.lastName += "Pole powinno zawierać od 2 do 32 znaków. ";
      this.setState({isError: true});
    }
    //EmailValidation
    errors.email = "";
    if (!Validator.isEmail(data.email)) {
      errors.email += "Pole powinno zawierać adres email. "
      this.setState({isError: true});
    }
    if (!Validator.isLength(data.email, 5, 120)) {
      errors.email += "Pole powinno zawierać od 5 do 120 znaków. ";
      this.setState({isError: true});
    }
    //PasswordValidation
    errors.password = "";
    errors.repeatedPassword = "";
    if (!Validator.isLength(data.password, 6, 32)) {
      errors.password += "Pole powinno zawierać od 6 do 32 znaków. ";
      this.setState({isError: true});
    }
    if (!Validator.equals(data.password, data.repeatedPassword)) {
      errors.password += "Wpisane hasła się nie zgadzają. ";
      errors.repeatedPassword += "Wpisane hasła się nie zgadzają. ";
      this.setState({isError: true});
    }
    //BirthDateValidation
    errors.birthdate = "";
    //TODO: Datepicer or smth...
    return errors;
  }

  render() {
    const {data, errors} = this.state;
    return (

            <div style={styles.root}>
            <Segment inverted style={styles.segment}>
              <Container textAlign="center" style={{'width': 600}}>
                <Header as='h1' textAlign='center' className="text-xs-center" inverted>
                <Icon name='signup' />
                  Zarejestruj
                </Header>
                <p style={font.root}>
                  <Link to="/login" style={font.linkFont}>
                    Masz konto?
                  </Link>
                </p>

                <Form onSubmit={this.onSubmit}>
                  

                    <Form.Field>
                      <label style={font.root}>Imię</label>
                      <Input transparent style={styles.input}
                        className="form-control form-control-lg"
                        type="text"
                        id="firstName"
                        name="firstName"
                        placeholder="Imie..."
                        value={data.firstName}
                        onChange={this.onChange}/>
                      <InlineError text={errors.firstName}/>
                    </Form.Field>

                    <Form.Field>
                      <label style={font.root}>Nazwisko</label>
                      <Input transparent style={styles.input}
                        className="form-control form-control-lg"
                        type="text"
                        id="lastName"
                        name="lastName"
                        placeholder="Nazwisko..."
                        value={data.lastName}
                        onChange={this.onChange}/>
                      <InlineError text={errors.lastName}/>
                    </Form.Field>

                    <Form.Field>
                      <label style={font.root}>E-mail</label>
                      <Input transparent style={styles.input}
                        className="form-control form-control-lg"
                        type="text"
                        id="email"
                        name="email"
                        placeholder="Email..."
                        value={data.email}
                        onChange={this.onChange}/>
                      <InlineError text={errors.email}/>
                    </Form.Field>

                    <Form.Field>
                      <label style={font.root}>Hasło</label>
                      <Input transparent style={styles.input}
                        className="form-control form-control-lg"
                        type="password"
                        id="password"
                        name="password"
                        placeholder="Hasło..."
                        value={data.password}
                        onChange={this.onChange}/>
                      <InlineError text={errors.password}/>
                    </Form.Field>

                    <Form.Field>
                      <label style={font.root}>Powtórz hasło</label>
                      <Input transparent style={styles.input}
                        className="form-control form-control-lg"
                        type="password"
                        id="repeatedPassword"
                        name="repeatedPassword"
                        placeholder="Powtórz hasło..."
                        border-bottom= "1px white"
                        value={data.repeatedPassword}
                        onChange={this.onChange}/>
                      <InlineError text={errors.repeatedPassword}/>

                    </Form.Field>

                    <Form.Field>
                      <label style={font.root}>Data urodzenia</label>
                      <Input transparent style={styles.input}
                        className="form-control form-control-lg"
                        id="birthdate"
                        name="birthdate"
                        placeholder="Data urodzenia RRRR.MM.DD"
                        type="text"
                        value={data.birthdate}
                        onChange={this.onChange}/>
                      <InlineError text={errors.birthdate}/>
                    </Form.Field>



                    <Button animated="vertical"
                        size="huge"  
                        type="submit">
                        <Button.Content visible>Zarejestruj</Button.Content>
                        <Button.Content hidden>
                          <Icon name="signup" />
                        </Button.Content>
                      </Button> 

                  
                </Form>
              </Container>
              </Segment>
            </div>

    );
  }
}

RegisterForm.propTypes = {
  submit: PropTypes.func.isRequired
}

export default RegisterForm;
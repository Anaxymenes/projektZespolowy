import React from 'react';
import { Link } from 'react-router-dom';
import Validator from 'validator';
import InlineError from '../common/InlineError';
import PropTypes from 'prop-types';
import { Button, Input, Header, Icon, Form, Label, Segment, Container } from 'semantic-ui-react';
//import Label from 'semantic-ui-react/dist/commonjs/elements/Label/Label';
//import FormField from 'semantic-ui-react/dist/commonjs/collections/Form/FormField';

const styles = {
  root: {
    display: 'flex',
    justifyContent: 'space-around',
    alignItems: 'center',
    height: '98vh',
    flexDirection: 'column'
  }
}
const fontSize = {
  root: {
    "fontSize": "20px"
  }
}
class LoginForm extends React.Component {
  state = {
    data: {
      email: "",
      password: ""
    },
    errors: {},
    isError: true,
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
    this.setState({ isError: false });
    event.preventDefault();
    const errors = this.validate(this.state.data);
    this.setState({ errors });
    if (!this.state.isError) {
      this.setState({ loading: true });
      this
        .props
        .submit(this.state.data)
      //TODO when Api ready
      //.catch(err => this.setState({errors: err.response.data.errors, loading: false}))
    }
  }
  validate = (data) => {
    const errors = {};
    this.setState({ isError: false });
    //EmailValidation
    errors.email = "";
    if (!Validator.isEmail(data.email)) {
      errors.email += "Pole powinno zawierać adres email. "
      this.setState({ isError: true });
    }
    if (!Validator.isLength(data.email, 5, 120)) {
      errors.email += "Pole powinno zawierać od 5 do 120 znaków. ";
      this.setState({ isError: true });
    }
    //PasswordValidation
    errors.password = "";
    if (!Validator.isLength(data.password, 6, 32)) {
      errors.password += "Pole powinno zawierać od 6 do 32 znaków. ";
      this.setState({ isError: true });
    }
    return errors
  }

  render() {
    const { data, errors } = this.state;
    return (
      <div className="auth-page">
        <div className="container page">
          <div className="row">

            <div style={styles.root}>
              <Container textAlign="center" style={{'width': 600}}>
                <Header as='h1' textAlign='center' className="text-xs-center" >
                <Icon name='sign in' />
                  Zaloguj
                </Header>

                <p style={fontSize.root}>
                  <Link to="/register">
                    Nie masz konta?
                  </Link>
                </p>

                <Form onSubmit={this.onSubmit}>
                  
                    <Segment inverted>
                      <Form.Field >
                      <label style={fontSize.root}>E-mail</label>  
                      <Input 
                          icon="mail"
                          iconPosition="left"
                          className="form-control form-control-lg"
                          type="text"
                          id="email"
                          name="email"
                          placeholder="Email..."
                          value={data.email}
                          onChange={this.onChange} />
                        <InlineError text={errors.email} />
                      </Form.Field>
                    
                      <Form.Field className="form-group">
                        <label style={fontSize.root}>Hasło</label>
                        <Input error={errors.password}
                          icon="lock"
                          iconPosition="left"
                          className="form-control form-control-lg"
                          type="password"
                          id="password"
                          name="password"
                          placeholder="Hasło..."
                          value={data.password}
                          onChange={this.onChange} />
                        <InlineError text={errors.password} />
                      </Form.Field>
                    </Segment>
                      <Button animated="vertical"
                        color='black'
                        size="huge"  
                        type="submit">
                        <Button.Content visible>Zaloguj</Button.Content>
                        <Button.Content hidden>
                          <Icon name="sign in" />
                        </Button.Content>
                      </Button> 
                      

                    
                </Form>
              </Container>
            </div>

          </div>
        </div>
      </div>
    );
  }
}


LoginForm.propTypes = {
  submit: PropTypes.func
}

export default LoginForm;
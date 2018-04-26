import React from 'react';
import {Link} from 'react-router-dom';
import Validator from 'validator';
import InlineError from '../common/InlineError';
import PropTypes from 'prop-types';

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
    event.preventDefault();
    const errors = this.validate(this.state.data);
    this.setState({errors});
    if (!this.state.isError) {
      this.setState({loading: true});
      this
        .props
        .submit(this.state.data)
        //.catch(err => this.setState({errors: err.response.data.errors, loading: false}))
        ;
    }
  }

  validate = (data) => {
    const errors = {};
    this.setState({isError: false});
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
      <div className="auth-page">
        <div className="container page">
          <div className="row">
            <div className="col-md-6 offset-md-3 col-xs-12">
              <h1 className="text-xs-center">Sign Up</h1>
              <p className="text-xs-center">
                <Link to="/login">
                  Have an account?
                </Link>
              </p>

              <form onSubmit={this.onSubmit}>
                <fieldset>

                  <fieldset className="form-group">
                    <input
                      className="form-control form-control-lg"
                      type="text"
                      id="firstName"
                      name="firstName"
                      placeholder="Imie..."
                      value={data.firstName}
                      onChange={this.onChange}/>
                    <InlineError text={errors.firstName}/>
                  </fieldset>

                  <fieldset className="form-group">
                    <input
                      className="form-control form-control-lg"
                      type="text"
                      id="lastName"
                      name="lastName"
                      placeholder="Nazwisko..."
                      value={data.lastName}
                      onChange={this.onChange}/>
                    <InlineError text={errors.lastName}/>
                  </fieldset>

                  <fieldset className="form-group">
                    <input
                      className="form-control form-control-lg"
                      type="text"
                      id="email"
                      name="email"
                      placeholder="Email..."
                      value={data.email}
                      onChange={this.onChange}/>
                    <InlineError text={errors.email}/>
                  </fieldset>

                  <fieldset className="form-group">
                    <input
                      className="form-control form-control-lg"
                      type="password"
                      id="password"
                      name="password"
                      placeholder="Hasło..."
                      value={data.password}
                      onChange={this.onChange}/>
                    <InlineError text={errors.password}/>
                  </fieldset>

                  <fieldset className="form-group">
                    <input
                      className="form-control form-control-lg"
                      type="password"
                      id="repeatedPassword"
                      name="repeatedPassword"
                      placeholder="Powtórz hasło..."
                      value={data.repeatedPassword}
                      onChange={this.onChange}/>
                    <InlineError text={errors.repeatedPassword}/>

                  </fieldset>

                  <fieldset className="form-group">
                    <input
                      className="form-control form-control-lg"
                      id="birthdate"
                      name="birthdate"
                      placeholder="Data urodzenia RRRR.MM.DD"
                      type="text"
                      value={data.birthdate}
                      onChange={this.onChange}/>
                    <InlineError text={errors.birthdate}/>
                  </fieldset>

                  <button className="btn btn-lg btn-primary pull-xs-right" type="submit">
                    Sign up
                  </button>

                </fieldset>
              </form>
            </div>

          </div>
        </div>
      </div>
    );
  }
}

RegisterForm.propTypes = {
  submit: PropTypes.func.isRequired
}

export default RegisterForm;
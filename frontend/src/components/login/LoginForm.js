import React from 'react';
import {Link} from 'react-router-dom';
import Validator from 'validator';
import InlineError from '../common/InlineError';
import PropTypes from 'prop-types';
import {Button, Input } from 'semantic-ui-react';

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
    this.setState({isError: false});
    event.preventDefault();
    const errors = this.validate(this.state.data);
    this.setState({errors});
   if (!this.state.isError) {
       this.setState({loading: true});
       this
       .props
       .submit(this.state.data)
        //TODO when Api ready
        //.catch(err => this.setState({errors: err.response.data.errors, loading: false}))
    }
  }
  validate = (data) => {
    const errors = {};
    this.setState({isError: false});
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
    if (!Validator.isLength(data.password, 6, 32)) {
      errors.password += "Pole powinno zawierać od 6 do 32 znaków. ";
      this.setState({isError: true});
    }
    return errors
  }

  render() {
    const {data, errors} = this.state;
    return (
      <div className="auth-page">
        <div className="container page">
          <div className="row">

            <div className="col-md-6 offset-md-3 col-xs-12">
              <h1 className="text-xs-center">Sign In</h1>
              <p className="text-xs-center">
                <Link to="/register">
                  Need an account?
                </Link>
              </p>

              <form onSubmit={this.onSubmit}>
                <fieldset>

                  <fieldset className="form-group">
                    <Input
                      icon="plane"
                      iconPosition="left"
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
                    <Input error={errors.password}
                     icon="car"
                      iconPosition="left"
                      className="form-control form-control-lg"
                      type="password"
                      id="password"
                      name="password"
                      placeholder="Hasło..."
                      value={data.password}
                      onChange={this.onChange}/>
                    <InlineError text={errors.password}/>
                  </fieldset>

                  <Button primary content = "Zaloguj"  type="submit" />
                    Sign in
                  
                </fieldset>
              </form>
            </div>

          </div>
        </div>
      </div>
    );
  }
}


LoginForm.propTypes ={
  submit: PropTypes.func
}

export default LoginForm;
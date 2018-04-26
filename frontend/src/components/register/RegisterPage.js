import React, { Component } from 'react';
import RegisterForm from './RegisterForm';
import PropTypes from 'prop-types';
import {connect} from 'react-redux';
import {signup} from '../../actions/user';


class RegisterPage extends Component {
    submit = data => this.props.signup(data).then(()=> this.props.history.push("/"));
    render() {
        return (
            <div>
                <RegisterForm submit = {this.submit}/>
            </div>
        );
    }
}

RegisterPage.propTypes = {
    history: PropTypes.shape({
        push: PropTypes.func.isRequired
    }).isRequired,
    signup: PropTypes.func
}

export default connect(null, {signup})(RegisterPage);
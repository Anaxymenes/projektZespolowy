import React, { Component } from 'react';
import LoginForm from './LoginForm';
import PropTypes from 'prop-types';
import { connect } from 'react-redux';
import {login} from '../../actions/auth';

class LoginPage extends Component {
    submit = data => this.props.login(data).then(() => this.props.history.push("/"));
    render() {
        return (
            <div>
                <LoginForm submit = {this.submit}/>
            </div>
        );
    }
}

LoginPage.propTypes ={
    login: PropTypes.func.isRequired,
    history: PropTypes.shape({
        push: PropTypes.func.isRequired
    }).isRequired
}
export default connect(null, {login})(LoginPage);
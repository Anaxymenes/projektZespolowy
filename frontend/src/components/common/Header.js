import React from 'react';
import { Link } from 'react-router-dom';
//import {Menu} from 'semantic-ui-react';

const Header = () => {
    return (
        <div>
            <Link to="/login"> Login</Link>
            <Link to="/register"> Register</Link>
            <Link to="/"> Home</Link>
            <Link to="/wall"> Wall</Link>
            <Link to ="/addNewPost"> Dodaj Post </Link>
        </div>
    );
};

export default Header;
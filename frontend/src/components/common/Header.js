import React, { Component } from 'react'
import { Link } from 'react-router-dom';
import {Menu} from 'semantic-ui-react';

class Header extends Component{

    state = { activeItem: 'home' }

    handleItemClick = (e, { name }) => this.setState({ activeItem: name })

    render (){
        const { activeItem } = this.state
        return (
            <Menu inverted>
                <Link to="/login"><Menu.Item name='zaloguj' active={activeItem === 'zaloguj'} onClick={this.handleItemClick} /></Link>
                <Link to="/register"><Menu.Item name='rejestracja' active={activeItem === 'rejestracja'} onClick={this.handleItemClick} /></Link>  
                <Link to="/"><Menu.Item name='strona główna' active={activeItem === 'strona główna'} onClick={this.handleItemClick} /></Link>
                <Link to="/wall"><Menu.Item name='tablica główna' active={activeItem === 'tablica główna'} onClick={this.handleItemClick} /></Link>
                <Link to ="/addNewPost"><Menu.Item name='dodaj post' active={activeItem === 'dodaj post'} onClick={this.handleItemClick} /></Link>
                <Link to ="/addNewGroup"><Menu.Item name='dodaj grupe' active={activeItem === 'dodaj grupe'} onClick={this.handleItemClick} /></Link>                
            </Menu>
        );
    }
}

export default Header;
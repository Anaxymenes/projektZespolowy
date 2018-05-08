import React, { Component } from 'react';
import Header from './common/Header';
import Routes from './Routes';
import Background from '../img/bg.jpg';


class App extends Component {
    render() {
        return (
            <div style={{backgroundImage: "url(" + Background + ")", 
            backgroundSize: 'cover',
            overflow: 'hidden',
            height: '100vh',}}>
                <Header />
                <Routes />
            </div>
        );
    }
}

export default App;
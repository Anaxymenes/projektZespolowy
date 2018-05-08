import React, { Component } from 'react';
import AddNewPageForm from './AddNewPageForm';
//import PropTypes from 'prop-types';
//import { connect } from 'react-redux';

const styles = {
    root: {
      display: 'flex',
      justifyContent: 'space-around',
      alignItems: 'center',
      height: '98vh',
      flexDirection: 'column'
    }
  }

class WallPage extends Component {

    render() {
        return (
            <div style={styles.root}>
                <AddNewPageForm />
            </div>
        );
    }
}

export default WallPage;
import React from 'react';

const styles = {
    root: {
      display: 'flex',
      justifyContent: 'space-around',
      alignItems: 'center',
      height: '98vh',
      flexDirection: 'column'
    }
  }

  
const Home = () => {
    return (
        <div style={styles.root}>
           Strona Główna
        </div>
    );
};
export default Home;
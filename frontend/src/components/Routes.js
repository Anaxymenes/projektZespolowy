import React from 'react';
import { Route, Switch } from 'react-router-dom';
import LoginPage from './login/LoginPage';
import RegisterPage from './register/RegisterPage';
import Home from './home/Home';
import WallPage from './wall/WallPage';
import AddNewPostPage from './post/AddNewPostPage';
import AddNewGroupContainer from './group/AddGroupContainer';

const Routes = () => {
    return (
    <Switch>
      <Route exact path='/' component={Home}/>
      <Route path='/login' component={LoginPage}/>
      <Route path='/register' component={RegisterPage}/>
      <Route path='/wall' component={WallPage}/>
      <Route path='/addNewPost' component={AddNewPostPage} />
      <Route path='/addNewGroup' component ={AddNewGroupContainer} />
    </Switch>
    );
};

export default Routes;
import React, { Component } from 'react';
import { Redirect, BrowserRouter as Router, Route } from 'react-router-dom';
import Header from './components/Header';
import Login from './components/Login';
import Register from './components/Register';
import Home from './components/Home';
import BreweryList from './components/BreweryList';
import { getUser, removeUser } from './API/userManager';
import './App.css';

class App extends Component {
  state = {
    user: getUser(),
    brewerySearchText: ""
  }

  logout = () => {
    this.setState({ user: null });
    removeUser();
  }

  stateHandler = (stateProperty, stateValue) => {
    this.setState({
      [stateProperty]: stateValue
    })
  }

  render() {
    return (
      <div className="App">
        <Router>
          <Header
            {...this.props}
            user={this.state.user}
            logout={this.logout}
            stateHandler={this.stateHandler}
          />
          <Route exact path="/login" render={() => (
            <Login onLogin={(user) => this.setState({ user })} />
          )} />
          <Route exact path="/register" render={() => (
            <Register onLogin={(user) => this.setState({ user })} />
          )} />
          <Route exact path="/" render={() => {
            return this.state.user ? (
              <Home />
            ) : <Redirect to="/login" />
          }} />

          <Route exact path="/breweries" render={() => {
            return this.state.user ? (
              <BreweryList
                {...this.props}
                brewerySearchText={this.state.brewerySearchText}
              />
            ) : <Redirect to="/login" />
          }} />
        </Router>
      </div>
    );
  }
}

export default App;

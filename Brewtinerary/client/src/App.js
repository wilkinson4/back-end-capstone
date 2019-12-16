import React, { Component } from 'react';
import { Redirect, BrowserRouter as Router, Route } from 'react-router-dom';
import Header from './components/Header';
import Login from './components/Login';
import Register from './components/Register';
import Home from './components/Home';
import BreweryList from './components/Breweries/BreweryList';
import AddBrewery from './components/Breweries/AddBrewery';
import ItineraryDetails from './components/Itineraries/ItineraryDetails';
import { getUser, removeUser } from './API/userManager';
import './App.css';

class App extends Component {
  state = {
    user: getUser(),
    brewerySearchText: "",
    itineraries: [],
    currentBrewery: {},
    currentItinerary: {}
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

          {/* ITINERARY ROUTES */}
          <Route exact path="/" render={() => {
            return this.state.user ? (
              <Home {...this.props} itineraries={this.state.itineraries} stateHandler={this.stateHandler} />
            ) : <Redirect to="/login" />
          }} />

          <Route path="/itineraries/:itineraryId(\d+)" render={() => {
            return this.state.user ? (
              <ItineraryDetails
                {...this.props}
                stateHandler={this.stateHandler}
                currentItinerary={this.state.currentItinerary}
              />
            ) : <Redirect to="/login" />
          }} />

          {/* BREWERY ROUTES */}
          <Route exact path="/breweries" render={() => {
            return this.state.user ? (
              <BreweryList
                {...this.props}
                stateHandler={this.stateHandler}
                brewerySearchText={this.state.brewerySearchText}
              />
            ) : <Redirect to="/login" />
          }} />
          <Route path="/breweries/add" render={() => {
            return this.state.user ? (
              <AddBrewery
                {...this.props}
                currentBrewery={this.state.currentBrewery}
                itineraries={this.state.itineraries}
              />
            ) : <Redirect to="/login" />
          }}
          />

        </Router>
      </div>
    );
  }
}

export default App;

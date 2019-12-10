import React, { Component } from 'react';
import { createAuthHeaders } from '../API/userManager';

class Home extends Component {
  state = {
    itineraries: [],
    textToFilterBy: ""
  }

  componentDidMount() {
    const authHeader = createAuthHeaders();
    fetch('/api/v1/itineraries', {
      headers: authHeader
    })
      .then(response => response.json())
      .then(itineraries => {
        this.setState({ itineraries: itineraries });
      });
  }

  filterValues = () => {
    const authHeader = createAuthHeaders();
    fetch(`/api/v1/itineraries?_filter=${this.state.textToFilterBy}`, {
      headers: authHeader
    }).then(response => response.json())
      .then(itineraries => {
        this.setState({ itineraries: itineraries });
      });
  }

  handleInputChange = (event) => {
    const { name, value } = event.target;
    this.setState({
      [name]: value,
    });
  }

  render() {
    return (
      <>
        <h1>Welcome to my app</h1>
        <ul>
          {
            this.state.itineraries.map(itinerary => <li>{itinerary.name}</li>)
          }
        </ul>
        <input onChange={this.handleInputChange} id="textToFilterBy" name="textToFilterBy" type="text" placeholder="Filter the itineraries" />
        <button onClick={this.filterValues}>Submit</button>
      </>
    )
  }
}

export default Home;
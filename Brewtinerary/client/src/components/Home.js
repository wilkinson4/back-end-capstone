import React, { Component } from 'react';
import { createAuthHeaders } from '../API/userManager';

class Home extends Component {
  state = {
    values: [],
    textToFilterBy: ""
  }

  componentDidMount() {
    const authHeader = createAuthHeaders();
    fetch('/api/v1/values', {
      headers: authHeader
    })
      .then(response => response.json())
      .then(values => {
        this.setState({ values: values });
      });
  }

  filterValues = () => {
    const authHeader = createAuthHeaders();
    fetch(`/api/v1/values?_filter=${this.state.textToFilterBy}`, {
      headers: authHeader
    }).then(response => response.json())
      .then(values => {
        this.setState({ values: values });
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
            this.state.values.map(value => <li>{value}</li>)
          }
        </ul>
        <input onChange={this.handleInputChange} id="textToFilterBy" name="textToFilterBy" type="text" placeholder="Filter the values" />
        <button onClick={this.filterValues}>Submit</button>
      </>
    )
  }
}

export default Home;
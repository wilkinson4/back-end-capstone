import React from 'react';
import { Map, InfoWindow, Marker, GoogleApiWrapper } from 'google-maps-react';

const MapContainer = (props) => {
  return (
    <Map google={props.google} zoom={14}>

      <Marker
        name={'Current location'} />

      <InfoWindow>
        <div>
          <h1>Name of Brewery</h1>
        </div>
      </InfoWindow>
    </Map>
  )
}

export default GoogleApiWrapper({
  apiKey: process.env.REACT_APP_GOOGLE_API_KEY
})(MapContainer)

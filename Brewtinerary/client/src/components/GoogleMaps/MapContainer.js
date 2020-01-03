import React, { useState, useEffect } from 'react';
import { Map, Marker, GoogleApiWrapper } from 'google-maps-react';
import GetGeocodeInfo from '../../API/geocode';

const style = {
  width: '500px',
  height: '500px'
}

const MapContainer = (props) => {

  const [initialCenter, updateInitialCenter] = useState({ lat: 0, lng: 0 })

  const points = props.breweries.map(b => {
    return { lat: parseFloat(b.latitude), lng: parseFloat(b.longitude) }
  })

  const bounds = new props.google.maps.LatLngBounds();
  for (let i = 0; i < points.length; i++) {
    bounds.extend(points[i]);
  }

  useEffect(() => {
    GetGeocodeInfo(`${props.currentItinerary.city},+${props.currentItinerary.state}`)
      .then(r => updateInitialCenter({ lat: r.results[0].geometry.location.lat, lng: r.results[0].geometry.location.lng }))
  }, [])

  return (
    <Map google={props.google} center={initialCenter} zoom={11} style={style}>

      {
        props.breweries.map(b =>
          <Marker
            key={b.id}
            title={b.name}
            name={b.name}
            position={{ lat: b.latitude, lng: b.longitude }} />
        )
      }

    </Map>
  )
}

export default GoogleApiWrapper({
  apiKey: process.env.REACT_APP_GOOGLE_API_KEY
})(MapContainer)

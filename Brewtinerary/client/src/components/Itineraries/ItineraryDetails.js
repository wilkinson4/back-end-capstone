import React, { useState, useEffect, useCallback } from "react";
import { useParams, useHistory } from 'react-router-dom';
import ItineraryManager from '../../API/itineraryManager';
import AddedBreweryCard from '../Breweries/AddedBreweryCard';
import { Map, GoogleApiWrapper, Marker, InfoWindow } from 'google-maps-react';


function ItineraryDetails(props) {
    const [showInfoWindow, updateShowInfoWindow] = useState(false)
    
    const { itineraryId } = useParams();

    const history = useHistory();

    const getItinerary = useCallback(() => {
        ItineraryManager.getAnItinerary(itineraryId)
            .then(itinerary => {
                props.stateHandler("currentItinerary", itinerary)
            })
    }, [itineraryId, props])

    useEffect(() => {
        getItinerary()
    }, [])


    return (

        <section className="itineraryDetails__section">
            <h1>Itinerary Details Page</h1>
            <div className="itineraryDetails__div">
                <h3>{props.currentItinerary.name}</h3>
                <p>{props.currentItinerary.shortDate}</p>
                <p>{`${props.currentItinerary.city}, ${props.currentItinerary.state}`}</p>
                <button className="button" onClick={() => history.push(`/itineraries/edit/${itineraryId}`)}>Edit Itinerary</button>
            </div>
            <div className="breweryList__div">
                <h3>Breweries</h3>
                {
                    !!props.currentItinerary.itineraryBreweryViewModels &&
                    props.currentItinerary.itineraryBreweryViewModels.map(ibvm => {
                        return <AddedBreweryCard
                            key={ibvm.brewery.id}
                            {...props}
                            brewery={ibvm.brewery}
                        />
                    })
                }
            </div>
        </section>
    )
}

export default ItineraryDetails;
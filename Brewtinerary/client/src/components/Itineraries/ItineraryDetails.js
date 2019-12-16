import React, { useEffect, useCallback } from "react";
import { useParams } from 'react-router-dom';
import ItineraryManager from '../../API/itineraryManager';
import AddedBreweryCard from '../Breweries/AddedBreweryCard';


function ItineraryDetails(props) {
    const { itineraryId } = useParams();

    const getItinerary = useCallback(() => {
        ItineraryManager.getAnItinerary(itineraryId)
            .then(itinerary => {
                if (props.currentItinerary.id !== itinerary.id) {
                    props.stateHandler("currentItinerary", itinerary)
                } else if(props.currentItinerary.hasOwnProperty("itineraryBreweryViewModels")) {
                    if(props.currentItinerary.itineraryBreweryViewModels.length !== itinerary.itineraryBreweryViewModels.length){
                        props.stateHandler("currentItinerary", itinerary)
                    }
                }
            })
    }, [itineraryId, props])

    useEffect(() => {
        getItinerary()
    }, [getItinerary])

    return (

        <section className="itineraryDetails__section">
            <h1>Itinerary Details Page</h1>
            <div className="itineraryDetails__div">
                <h3>{props.currentItinerary.name}</h3>
                <p>{props.currentItinerary.dateOfEvent}</p>
                <p>{`${props.currentItinerary.city}, ${props.currentItinerary.state}`}</p>
            </div>
            <div className="breweryList__div">
                <h3>Breweries</h3>
                {
                    props.currentItinerary.hasOwnProperty("itineraryBreweryViewModels") &&
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
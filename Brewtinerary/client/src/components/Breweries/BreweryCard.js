import React from 'react';
import { useHistory } from 'react-router-dom';

function BreweryCard(props) {
    const history = useHistory()

    const onClick = () => {
        history.push("/breweries/add")
        return props.stateHandler("currentBrewery", props.brewery)
    }

    return (
        <div className="breweryCard__div">
            <div className="cardHeader__div">
                <h3 className="brewery__h3">{props.brewery.name}</h3>
                <button
                    className="button"
                    onClick={onClick}>
                    Add To Itinerary
                    </button>
            </div>
            <div className="cardBody__div">
                <p>{props.brewery.street}, {props.brewery.city}, {props.brewery.state}, {props.brewery.postal_Code}</p>
                <p>{props.brewery.phone}</p>
                {
                    props.brewery.website_url !== "" &&
                    <a
                        href={props.brewery.website_url}
                        target="_blank"
                        rel="noopener noreferrer"
                    >
                        Website
                    </a>
                }
            </div>
        </div>
    )
}

export default BreweryCard
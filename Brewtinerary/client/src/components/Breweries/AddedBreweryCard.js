import React from 'react';

function AddedBreweryCard(props) {
    return (
        <div className="addedBreweryCard__div">
            <h4>{props.brewery.name}</h4>
            <p>{props.brewery.street}, {props.brewery.city}, {props.brewery.state}, {props.brewery.postal_code}</p>
            <p>{props.brewery.phone}</p>
            {
                props.brewery.website_URL &&
                <a
                    href={props.brewery.website_URL}
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Website
                </a>
            }
        </div>
    )
}

export default AddedBreweryCard;
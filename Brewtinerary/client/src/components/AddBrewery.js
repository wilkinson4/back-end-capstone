import React, { useState } from 'react';
import Select from 'react-select';
import './css/AddBrewery.css'


function AddBrewery(props) {
    const [selectedItinerary, updateSelectedItinerary] = useState({})

    const options = props.itineraries.map(i => {
        return { value: i.id, label: i.name }
    });

    function handleChange(selectedOption) {
        updateSelectedItinerary(selectedOption);
    };

    function addBrewery() {
        // check if an itinerary is selected
        if (selectedItinerary.hasOwnProperty("value")) {
            fetch(`/api/v1/breweries/create/${selectedItinerary.value}`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(props.currentBrewery)
            })
        }
    }

    return (
        <section className="selectItinerary__section">
            <h1>Please Select an Itinerary</h1>
            {
                <Select
                    defaultValue="Please select an itinerary to add to"
                    value={selectedItinerary}
                    onChange={handleChange}
                    options={options}
                />
            }
            <button onClick={addBrewery}>Add Brewery</button>
        </section>
    )
}

export default AddBrewery
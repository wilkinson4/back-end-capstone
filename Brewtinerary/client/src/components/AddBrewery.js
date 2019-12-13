import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import Select from 'react-select';
import './css/AddBrewery.css'
import BreweryManager from '../API/breweryManager';


function AddBrewery(props) {
    const [selectedItinerary, updateSelectedItinerary] = useState({})
    const history = useHistory()

    const options = props.itineraries.map(i => {
        return { value: i.id, label: i.name }
    });

    function handleChange(selectedOption) {
        updateSelectedItinerary(selectedOption);
    };

    function addBrewery() {
        // check if an itinerary is selected
        if (selectedItinerary.hasOwnProperty("value")) {
            BreweryManager.addBreweryToItinerary(selectedItinerary, props.currentBrewery)
            history.push("/")
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
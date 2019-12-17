import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import ItineraryManager from '../../API/itineraryManager';

function EditItinerary(props) {
    const [itinerary, updateItinerary] = useState({name: props.currentItinerary.name , date: props.currentItinerary.dateOfEvent, city: props.currentItinerary.city, state: props.currentItinerary.state })

    const history = useHistory();

    // format date to yyyy-mm-dd display it as defaultValue of date inputs
    const formatDate = (date) => {
        var d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();

        if (month.length < 2)
            month = '0' + month;
        if (day.length < 2)
            day = '0' + day;

        return [year, month, day].join('-');
    }

    const handleInputChange = e => {
        const { name, value } = e.target
        updateItinerary({ ...itinerary, [name]: value })
    }

    const saveChanges = () => {
        const editedItinerary = itinerary
        editedItinerary.id = props.currentItinerary.id
        ItineraryManager.editItinerary(editedItinerary.id, editedItinerary)
        .then(editedItinerary => history.push("/"))
    }

    return (
        <section className="editItinerary__section">
            <h1>Edit Itinerary</h1>
            <div className="itineraryName__div">
                <label htmlFor="name">Name </label>
                <input type="text" name="name" id="name" defaultValue={props.currentItinerary.name} onChange={handleInputChange} />
            </div>
            <div className="itineraryDate__div">
                <label htmlFor="date">Date </label>
                <input type="date" name="date" id="date" defaultValue={formatDate(props.currentItinerary.dateOfEvent)} onChange={handleInputChange} />
            </div>
            <div className="itineraryCity__div">
                <label htmlFor="city">City </label>
                <input type="text" name="city" id="city" defaultValue={props.currentItinerary.city} onChange={handleInputChange} />
            </div>
            <div className="itineraryState__div">
                <label htmlFor="state">State </label>
                <input type="text" name="state" id="state" defaultValue={props.currentItinerary.state} onChange={handleInputChange} />
            </div>
            <button onClick={() => saveChanges()}>Save Changes</button>
        </section>
    )
}

export default EditItinerary;
import { createAuthHeaders } from '../API/userManager';

const url = "/api/v1/itineraries"
const authHeader = createAuthHeaders();

export default {

    getAllItineraries() {
        return fetch(url, {
            headers: authHeader
        })
            .then(response => response.json())
    },

    getAnItinerary(id) {
        return fetch(`${url}/${id}`, {
            headers: authHeader
        })
        .then(response => response.json())
    }

}
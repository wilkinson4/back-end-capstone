import { createAuthHeaders } from '../API/userManager';

const url = "/api/v1/itineraries"

export default {

    getAllItineraries() {
        const authHeader = createAuthHeaders();
        return fetch(url, {
            headers: authHeader
        })
            .then(response => response.json())
    }

}
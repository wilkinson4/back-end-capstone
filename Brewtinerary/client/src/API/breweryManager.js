const url = "/api/v1/breweries"

export default {
    getThirdPartyBreweries(searchText) {
        return fetch(`${url}?filterText=${searchText}`)
            .then(response => response.json())
    }
}
const url = "https://maps.googleapis.com/maps/api/geocode/json?address="

const getGeoCodeInfo = (address) => {
    return fetch(`${url}${address}&key=${process.env.REACT_APP_GOOGLE_API_KEY}`)
        .then(response => response.json())
}

export default getGeoCodeInfo

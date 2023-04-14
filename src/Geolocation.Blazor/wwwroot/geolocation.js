export const getPositionAsync = () => {
    return new Promise((resolve, reject) => {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(returnPosition, returnError, { enableHighAccuracy: true, maximumAge: 0 });
        }

        function returnPosition(position) {
            resolve({
                latitude: position.coords.latitude,
                longitude: position.coords.longitude
            });
        }

        function returnError(error) {
            let errorMessage;
            switch (error.code) {
                case error.PERMISSION_DENIED:
                    errorMessage = 'User denied the request for Geolocation';
                    break;
                case error.POSITION_UNAVAILABLE:
                    errorMessage = "Location information is unavailable";
                    break;
                case error.TIMEOUT:
                    errorMessage = 'The request to get user location timed out!';
                    break;
                case error.UNKNOW:
                    errorMessage = 'An unknow error ocurred';
                    break;
            }
            reject(errorMessage);
        }
    });
}
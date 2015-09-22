// map
var styles = []


var styledMap = new google.maps.StyledMapType(styles,
  { name: "Styled Map" })


var mapOptions = {
    zoom: 15,
    center: new google.maps.LatLng(52.301601, -0.694009),
    scrollwheel: false,


    // disable mapType-top_right corner
    mapTypeControl: false,
    disableDefaultUI: false,
    draggable: true,
    mapTypeControlOptions: {
        mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map']
    }
};
var map = new google.maps.Map(document.getElementById('map'),
mapOptions);


var marker1 = new google.maps.Marker({
    position: new google.maps.LatLng(52.302458, -0.693976),
    map: map,
    icon: 'images/marker.png' // This path is the custom pin to be shown. Remove this line and the proceeding comma to use default pin
});






map.mapTypes.set('map', styledMap);
map.setMapTypeId('map');
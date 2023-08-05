function CalDistance(dist) {
    const token = document.cookie.split(';')[0].split('=')[1];
    var steps = [];
    const options = {
        method: 'POST',
        headers: {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({distance: dist})
    }
    fetch("https://trading-webapp.azurewebsites.net//api/delivery", options)
        .then(response => { return response.json() })
        .then(data => {
            for (let ele of data) { steps.push(ele) }
            localStorage.setItem('steps', JSON.stringify(steps))
            window.location.href = "https://auto-logistics-distribute.azurewebsites.net/Order/Graph"
        })
        .catch(err => console.log(err.message))
    
}
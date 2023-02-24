import React, { Component } from 'react';
import axios from 'axios'

class FlightsList extends Component {
    constructor(props) {
        super(props)
        this.state = {
            flights: []
        }
    }

    componentDidMount() {
        axios.get('https://localhost:7161/api/Flight')
        .then(response => {
            //console.log(response)
            this.setState({flights: response.data})
        })
        .catch(error => {
            console.log(error)
        })
    }

    render() {
        const { flights } = this.state
        return (
            <div>
                List of flights
                {
                    flights.map(flight => <div key={flight.id}>{flight.name} / {flight.company} / {flight.departureCity} - {flight.arriveCity}</div>)
                }
            </div>
        )
    }
}

export default FlightsList

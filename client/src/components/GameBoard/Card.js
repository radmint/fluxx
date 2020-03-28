import React, { Component } from 'react';

export default class Card extends Component {
    render() {
        return(
            <div>
                <div className="card">
                    <p className="text-center">{this.props.card.title}</p>
                </div>
            </div>
        )

    }
}

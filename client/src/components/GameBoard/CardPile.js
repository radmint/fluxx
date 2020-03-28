import React, { Component } from 'react';

export default class CardPile extends Component {
    render() {
        return(
            <div className={this.props.className}>
                <div className="card">
                    <p className="text-center">{this.props.text}</p>
                </div>
            </div>
        )

    }
}

import React, { Component } from 'react';
import Card from './Card';

export default class Hand extends Component {
    render() {
        var element;
        if(this.props.cards === [] || this.props.cards === null)
        {
            element = <p>No cards yet</p>
        } else {
            element = this.props.cards.map((card, i) => {
                return (<Card key={i} card={card} />)
            })
        }

        return(
            <div>
                {element}
            </div>
        )

    }
}

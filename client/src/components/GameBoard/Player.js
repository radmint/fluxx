import React, { Component } from 'react';

export default class Player extends Component {
    render() {
        let style = {
            borderColor: this.props.player.color,
            borderStyle: 'solid',
            borderWidth: 3
        };
        let textStyle = {
            color: this.props.player.color
        };
        
        return (
            <div className="col-sm text-center bg-secondary" style={style}>
                <h2 style={textStyle}>{this.props.player.name}</h2>
                <h2 className="text-capitalize" style={textStyle}>{this.props.player.color}</h2>
            </div>
        );
    }
}
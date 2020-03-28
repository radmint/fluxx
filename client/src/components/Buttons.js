import React, { Component } from 'react';

export class Buttons extends Component {

    render() {  
        if (!this.props.inGame) {
            return (
                <div className="text-center">
                    <a className="btn btn-success" href="/gameboard" role="button">Join game</a>
                    <a className="btn btn-success" href="/" role="button">Start game</a>  
                </div>
            )
        }
        return (            
            <div className="text-center">
                <a className="btn btn-success" href="/gameboard" role="button">Play Again</a>
                <a className="btn btn-danger" href="/" role="button">Quit</a>                
            </div>
        );
    }
}
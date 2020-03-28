import React, { Component } from 'react';
import CardPile from './CardPile';
import Player from './Player';
import Hand from './Hand';
import Keepers from './Keepers';
import { Button } from 'reactstrap';

export default class Board extends Component {
    render() {
        console.log(this.props);
        var player = this.props.gameBoard.players[0];
        var playerCount = this.props.gameBoard.players.length;

        return(
            <div>
                {this.props.gameHasBegun &&
                    <div>
                        <div className="row mt-3">
                            <CardPile className="col-12 col-md-3 offset-md-3 col-sm-6" text="Draw"/>
                            <CardPile className="col-12 col-md-3 col-sm-6" text="Discard"/>
                        </div>
                        <div className="row mt-3">
                            <Hand cards={player.hand}/>
                        </div>
                        <div className="row mt-3">
                            <Keepers cards={player.playedKeepers}/>
                        </div>
                    </div>
                }

                {!this.props.gameHasBegun && playerCount > 1 &&
                    <Button>Begin game with players {this.props.gameBoard.players.map((i, player) => { return ( <span>player.name</span> ) })}</Button>
                }

                <div className="row mt-3">
                    <Player player={player}/>
                </div>
            </div>
        )

    }
}

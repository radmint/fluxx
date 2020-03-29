import React, { Component } from 'react';
import { HubConnectionBuilder, LogLevel } from '@aspnet/signalr';
import Landing from './Landing/Landing';
import Board from './GameBoard/Board';

export default class Game extends Component {
    constructor(props) {
        super(props)
        this.state = {
            board: null,
            hubConnection: null,
            inGame: false,
            gameHasBegun: false,
            players: [],
        }
    }

    async componentDidMount() {        
        const hubConnection = new HubConnectionBuilder()
            .withUrl("/game")
            .configureLogging(LogLevel.Information).build();

        this.setState({ hubConnection }, () => {
            this.state.hubConnection
                .start()
                .catch(err => console.log('Error while establishing connection :('));

            this.state.hubConnection.on('renderBoard', board => {
                console.log('board rendering');
                this.setState({ board: board })
            });

            // this.state.hubConnection.on('color', color => {
            //     this.setState({ color: color })
            // });
            // this.state.hubConnection.on('turn', player => {
            //     if (player === this.state.color) {
            //         this.setState({ message: "You're up. What's your move?", yourTurn: true, showButtons: false })
            //     } else {
            //         this.setState({ message: player + ' is thinking...', yourTurn: false, showButtons: false })
            //     }
            // });

            // this.state.hubConnection.on('rollcall', (player1, player2) => {
            //     this.setState({ player1: player1, player2: player2, })
            // });

            // this.state.hubConnection.on('concede', () => {
            //     this.setState({ message: 'Your opponent conceded. You win', yourTurn: false, showButtons: true })
            //     this.state.hubConnection.stop()
            // });

            // this.state.hubConnection.on('victory', (player, board) => {
            //     let newState = { yourTurn: false }
            //     if (player === this.state.color) {
            //         newState['message'] = 'You win!'
            //     } else {
            //         newState['message'] = 'You lose!'
            //     }
            //     newState["board"] = board;
            //     newState["showButtons"] = true;
            //     this.setState(newState)
            //     this.state.hubConnection.stop()
            // });
        });
    }

    onStartGame = username => 
        this.state.hubConnection.invoke('startGame', username)
            .then((gameState) => {
                console.log(gameState);
                console.log(this.state);
                this.setState({inGame: true});
            })
            .catch(err => console.error(err));

    onJoinGame = (gameId, username) => 
        this.state.hubConnection.invoke('joinGame', gameId, username)
            .then((gameState) => {
                console.log(gameState);
                console.log(this.state);
                this.setState({inGame: true});
            })
            .catch(err => console.error(err));

    render() {
        var view;
        if(!this.state.inGame)
        {
            view = <Landing handleOnStart={this.onStartGame}
                            handleOnJoin={this.onJoinGame}/>
        }
        else {
            view = <Board gameBoard={this.state.board}
                          gameHasBegun={this.state.gameHasBegun}/>;
        }

        return (
            <div>
                {view}
            </div>
        )
    }
};
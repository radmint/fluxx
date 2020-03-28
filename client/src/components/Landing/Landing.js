import React, { Component } from 'react';
import Inputs from './Inputs';
import JoinOrStartButtons from './JoinOrStartButtons'

export default class Landing extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '', 
            gameId: '',
            joinOrStartSelected: null,
        };
    
        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleClick = this.handleClick.bind(this);
        this.handleGameSubmit = this.handleGameSubmit.bind(this);
    }

    handleChange(event) {
        if(event.target.name === 'username')
        {
            this.setState({username: event.target.value});
        } 
        else if (event.target.name === 'gameId')
        {
            this.setState({gameId: event.target.value});
        }
    }

    handleSubmit(event) {
        event.preventDefault();
        this.setState({joinOrStartSelected: event.target.id});
    }

    handleClick(event) {
        event.preventDefault();
        this.setState({joinOrStartSelected: null});
    }

    handleGameSubmit(event) {
        if(this.state.joinOrStartSelected === 'start'){
            this.props.handleOnStart(this.state.username);
        } else if (this.state.joinOrStartSelected === 'join'){
            this.props.handleOnJoin(this.state.gameId, this.state.username);
        }
    }

    render() {
        let start;
        if(this.state.joinOrStartSelected === null){
            start = <JoinOrStartButtons 
                            handleSubmit={this.handleSubmit}/>
        } else{
            start = <Inputs username={this.state.username}
                            handleClick={this.handleClick}
                            handleChange={this.handleChange} 
                            handleSubmit={this.handleGameSubmit}
                            joinOrStartSelected={this.state.joinOrStartSelected}
                            gameId={this.state.gameId}/>
        }
        return (
            <div>
                <div className="row">
                    <div className="col-12">
                        <h1 className="display-3 text-center">Fluxx</h1>
                    </div>
                </div>

                {start}
            </div>
        );
    }
}
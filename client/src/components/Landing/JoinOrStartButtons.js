import React, { Component } from 'react';

export default class JoinOrStartButtons extends Component {
    render() {
        return (                     
            <div id="button-container" className="row mt-3">
                <div className="col-sm-5 col-12 mt-3 text-center">
                    <form id="start" onSubmit={this.props.handleSubmit}>
                        <button type="submit" className="btn btn-primary" id="start-game">Start new game</button>
                    </form>
                </div>

                <div className="col-sm-2 col-12 mt-3 text-center">
                    <span className="align-middle">OR</span>
                </div>
            
                <div className="col-sm-5 col-12 mt-3 text-center">
                    <form id="join" onSubmit={this.props.handleSubmit}>
                        <button type="submit" className="btn btn-primary" id="join-game">Join game</button>
                    </form>
                </div>
            </div>
        );
    }
}
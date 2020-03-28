import React, { Component } from 'react';

export default class Inputs extends Component {
    render() {
        return (
            <div id="form-inputs">
                <div className="form-group">
                    <button type="button" className="btn btn-primary" id="back" onClick={this.props.handleClick}>Back</button>
                </div>

                <div className="form-group">
                    <input type="text" 
                            value={this.props.username}
                            name="username" 
                            className="form-control" 
                            placeholder="Display name" 
                            aria-label="Display name" 
                            maxLength="15" 
                            required="required"
                            onChange={this.props.handleChange}
                    />
                </div>
                {this.props.joinOrStartSelected === 'join' &&
                    <div className="form-group">
                        <input type="text" 
                                name="gameId"  
                                value={this.props.gameId} 
                                className="form-control" 
                                placeholder="Game Id" 
                                aria-label="Game Id" 
                                required="required"
                                onChange={this.props.handleChange}
                        />
                    </div>
                }

                <div className="form-group">
                    <button type="submit" 
                            className="btn btn-primary" 
                            id="back" 
                            onClick={this.props.handleSubmit}>
                        {this.props.joinOrStartSelected === 'join' ? 'Join' : 'Start'}
                    </button>
                </div>
            </div>
        )
    }
}
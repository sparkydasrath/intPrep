import * as React from 'react';

class PlayComp extends React.Component {

    render() {
        return <h1>Hello, {this.props.children}</h1>
    }
}

export default PlayComp;
import * as React from 'react';
import './App.css';
import TestComponent from './Components/TestComponent';

class App extends React.Component {
  public render() {
    const test = [];
    for (let index = 0; index < 3; index++) {
      test.push(<TestComponent />);
    }
    return (
      <div className="App">
        <header className="App-header">
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.tsx</code> and save to reload.
        </p>

        <h3>{test}</h3>

      </div>
    );
  }
}

export default App;

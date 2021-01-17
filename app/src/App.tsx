import { ThemeProvider } from '@material-ui/core';
import { theme } from './theme';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from 'react-router-dom';

import { routes } from './routes';


export const App: React.FC = () => {
  return (
    <ThemeProvider theme={theme}>
      <Router>
        <Switch>
          {routes.map(({ name, path, component }) =>
            <Route
              key={name}
              path={path}
              component={component}
            />
          )}
        </Switch>
      </Router>
    </ThemeProvider>
  );
}
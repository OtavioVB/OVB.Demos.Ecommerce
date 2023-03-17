import {BrowserRouter as Router, Route, Routes} from 'react-router-dom'
import NotFound from './routes/NotFound/NotFound.js';
import LandingPage from './routes/LandingPage/LandingPage.js';
import ServerStatus from './routes/Server/Status/ServerStatus.js';

export default function App(){
    return (
        <Router>
            <Routes>
                <Route exact path="/server/status" caseSensitive={false} element={<ServerStatus/>}></Route>
                <Route exact path="/" caseSensitive={false} element={<LandingPage/>}></Route>
                <Route path="*" element={<NotFound/>}/>
            </Routes>
        </Router>
    );
}
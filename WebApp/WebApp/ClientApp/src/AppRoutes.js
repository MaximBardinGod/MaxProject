import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import {Mentors} from "./components/Mentors";

const AppRoutes = [
  {
    path: '/home',
    element: <Home />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/mentors',
    element: <Mentors />
  }
];

export default AppRoutes;

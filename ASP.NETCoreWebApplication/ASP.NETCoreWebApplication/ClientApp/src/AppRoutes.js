import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import {Mentors} from "./components/Mentors";
import { Informations } from "./components/Informations";

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
  },
  {
    path: '/informations',
    element: <Informations />
  }
];

export default AppRoutes;

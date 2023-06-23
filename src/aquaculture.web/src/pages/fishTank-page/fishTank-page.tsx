import { fishTanksTemp } from '../../tempContracts';
import FishTankForm from './fishTank-form/fishTank-form';
import './fishTank-page.css';

const FishTankPage: React.FC = () => {
    return (
        <div className="fishTank-page">
            <FishTankForm fishTanks={fishTanksTemp}/>
        </div>
    );
}

export default FishTankPage;
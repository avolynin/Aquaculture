import DevicesForm from './devices-form/devices-form';
import './devices-page.css';

const DevicesPage: React.FC = () => {
    return (
        <div className="devices-page">
            <DevicesForm />
        </div>
    );
}

export default DevicesPage;
import MeasurementsForm from './measurements-form/measurements-form';
import './measurements-page.css';

const MeasurementsPage: React.FC = () => {
    return (
        <div className="measurements-page">
            <MeasurementsForm />
        </div>
    );
}

export default MeasurementsPage;
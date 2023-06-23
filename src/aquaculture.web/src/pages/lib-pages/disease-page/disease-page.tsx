import DiseaseForm from './disease-form/disease-form';
import './disease-page.css';

const DiseasePage: React.FC = () => {
    return (
        <div className="disease-page">
            <DiseaseForm />
        </div>
    );
}

export default DiseasePage;
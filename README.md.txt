 Macular Edema Detection

This is my academic project to detect Macular Edema using OCT (Optical Coherence Tomography) images and deep learning models.


Software Used

- Operating System:Windows 10
- IDE / Environment: Visual Studio 2022
- Frontend: ML.NET and C#
- Server: IIS
- Database: SQL Server 2022 or higher


 Project Structure

-'drd/' → Code files
- 'dataset/' → OCT image dataset used for training/testing
- 'docs/' → Presentation slides



 About the Project

This project segments retinal fluid from OCT images to detect macular cystoid edema. It uses:
- Convolutional Neural Networks (CNN)
- Fully Convolutional Networks (FCN)
- SVM classification
- Attention gates for better segmentation




 Results

 Model          | Accuracy 
----------------|----------
 CNN            | 93%      
 CNN + SVM      | 97%     



 Dataset

I used the "OCTID database", which contains retinal OCT images with annotated layers for training the model.
This dataset includes manually annotated retinal layers and is widely used in macular edema and diabetic retinopathy segmentation tasks.

Algorithms Used

- Fully Convolutional Network (FCN) with Attention Gates  
- Support Vector Machine (SVM) for classification  
- Data Segmentation using medical image preprocessing  
- Euclidean distance transform for class balancing  

Future Scope

Integration with portable devices for real-time diagnosis

Predictive analytics for treatment response

Use of multimodal data and deep learning enhancements
 
Presentation

You can find the project PowerPoint in the '/docs' folder.

 Author
Parvathy G S 


## used to encode directories of .jpg photos in conjunction with project: 
## https://github.com/ageitgey/face_recognition
## 
## on VM: https://medium.com/@ageitgey/try-deep-learning-in-python-now-with-a-fully-pre-configured-vm-1d97d4c3e9b
## 
## -cbadal
import sys
import os
import face_recognition

def GetFiles(path):
    print("GetFiles: " + path)
    if os.path.isfile(path):
        return [path] if path.endswith(('.jpg', '.png')) else []
    file_list =[]
    if os.path.isdir(path):
        for root, dirs, files in os.walk(path):
            for file in files:
                if file.endswith(('.jpg', '.png')):
                    file_list.append(os.path.join(root, file))
    return file_list

def WriteFile(path, content):
    with open(path, "w") as file:
        file.write(content)
        print("WriteFile: " + path)

# usage encode_photos.py <photo_dir|photo.jpg> <encoding_dir>
# process the onput photos, save encoding to <encoding_dir>/<photoname.jpg>.encoding
if len(sys.argv) < 3:
    print("encode_photos.py process photos for face recognition data, store encodings for later use.")
    print("Usage: ")
    print("   encode_photos.py <photo_dir|photo.jpg> <encoding_dir>")
    print("1st  arg is either an image or a directory of images to process.")
    print("2nd arg is the directory sto store the photo encodings")
    print("args:")
    for i, arg in enumerate(sys.argv):
        print("arg {} = {}".format(i, arg))
    sys.exit(0)
files_to_process = GetFiles(sys.argv[1])
save_to_dir = sys.argv[2]

print("Gathered {} files save encodings to {}".format(len(files_to_process), save_to_dir))

for photo_path in files_to_process:
    #photo_path = "/home/deeplearning/Downloads/NFL2K5Tool/PlayerData/bp.jpg"
    ## Simple case first, just do 1 photo
    #photo_ = face_recognition.load_image_file(sys.argv[1])
    encoding_file = save_to_dir + os.path.basename(photo_path) + ".face_encoding"
    try:
        if not os.path.exists(encoding_file):
            photo_ = face_recognition.load_image_file(photo_path)
            photo_encoding = face_recognition.face_encodings(photo_)[0]
            str_encoding = str(photo_encoding)
            WriteFile(encoding_file, str_encoding)
    except Exception as e:
        print("An error occured: {} {}".format(encoding_file, e))

